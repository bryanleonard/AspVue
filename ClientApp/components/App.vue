<template>
    <div>
        <h1>Welcome to Hands on Vue.js with ASP.NET Core!</h1>
        <p>
            The time is now: {{ time }}
        </p>
        
        <p>The current users of our system are:</p>
        <ul>
            <li v-for="user in users" :key="user.userName">
                {{ user.fullName }} - {{ user.userName }}
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name: 'app',
    data() {
        return {
            users: [],
            time: new Date().toString()
        }
    },
    mounted () {
        fetch('/api/users')
            .then(response => {
                return response.json()
            })
            .then(data => {
                this.users = data
            })
    }

}
</script>
